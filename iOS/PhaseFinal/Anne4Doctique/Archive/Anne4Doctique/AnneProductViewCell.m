//
//  AnneProductViewCell.m
//  Anne&DocTique2
//
//  Created by Kapi on 28/05/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "AnneProductViewCell.h"
#import "AnneProduct.h"

@interface AnneProductViewCell ()
@property (strong, nonatomic) IBOutlet UILabel *titleLabel;
@property (strong, nonatomic) IBOutlet UILabel *detailsLabel;
@property (strong, nonatomic) IBOutlet UILabel *dateLabel;
//@property (strong, nonatomic) IBOutlet UIImageView *iconView;


@end

static NSString *defaultIconName = @"defaultIcon";
static NSString *failedIconName = @"failedIcon";

@implementation AnneProductViewCell

+ (void)setDefaultIconName:(NSString *)name {
    defaultIconName = name;
}

+ (void)setFailedIconName:(NSString *)name; {
    failedIconName = name;
}

- (void)awakeFromNib {
    [super awakeFromNib];
    
    self.backgroundColor = [UIColor whiteColor];
    
    UIView* selectedBGView = [[UIView alloc] initWithFrame:self.bounds];
    selectedBGView.backgroundColor = self.tintColor;
    self.selectedBackgroundView = selectedBGView;
    
    //self.iconView.layer.cornerRadius = 16;
    //self.iconView.layer.masksToBounds = YES;
}

- (void)setProduct:(AnneProduct *)product {
    if (![product isEqual:_product]) {
        _product = product;
        self.detailsLabel.text = _product.description;
        self.titleLabel.text = _product.author;
        self.dateLabel.text = _product.date;
        //self.iconView.image = [UIImage imageNamed:defaultIconName];
        /*NSURLRequest *request = [NSURLRequest requestWithURL:_product.imageURL];
        [NSURLConnection sendAsynchronousRequest:request
                                           queue:[NSOperationQueue mainQueue]
                               completionHandler:^(NSURLResponse *response, NSData *data, NSError *connectionError)
         {
             // This includes an extra check to make sure we're still showing the same
             // product, in case this cell has been re-used.
             UIImage *image = nil;
             if (data &&
                 ((NSHTTPURLResponse *)response).statusCode == 200 &&
                 product == _product &&
                 (image = [UIImage imageWithData:data])) {
                 self.iconView.image = image;
             } else {
                 self.iconView.image = [UIImage imageNamed:failedIconName];
             }
         }];*/
    }
}

@end
