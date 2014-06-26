//
//  DetailViewController.h
//  Anne3Doctique
//
//  Created by Kapi on 19/06/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface DetailViewController : UIViewController
@property (strong, nonatomic) id texteAAfficher;
@property (strong, nonatomic) id detailItem;
@property (strong, nonatomic) IBOutlet UILabel *detailDescriptionLabel;
@property (weak, nonatomic) IBOutlet UILabel *donneeRecue;
@end