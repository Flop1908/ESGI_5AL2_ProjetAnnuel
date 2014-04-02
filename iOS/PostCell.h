//
//  PostCell.h
//  A&D
//
//  Created by Kapi on 25/03/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "ImageCache.h"

@interface PostCell : UITableViewCell {
	NSMutableDictionary * post;
	UIViewController * postController;
	CGRect buttonFrame;
	BOOL isEditing;
}

@property (nonatomic, retain) NSMutableDictionary *post;
@property (nonatomic, retain) UIViewController * postController;

- (IBAction) imageReadyCallback: (id)sender;

@end
